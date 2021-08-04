import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {
  IAccount,
  ServerMessage,
  ServerMessageWithToken,
  RefreshToken,
  IAccountChanging,
  AccountMassege, IPost
} from "./interfaces.service";
import {map, tap} from 'rxjs/operators';
import {Observable, of} from "rxjs";
import {BaseUrl} from "./shared.module";
import {JwtHelperService} from "@auth0/angular-jwt";
import {AccountRepositoryService} from "./account-repository.service";
import {ListOfLinksService} from "./list-of-links.service";

export const ACCESS_TOKEN_KEY = "Jwt_token_here"
export const REFRESH_TOKEN = "Refresh_Token"

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {

  constructor(private http: HttpClient, private  accountService: AccountRepositoryService,
              @Inject(BaseUrl) private baseurl, private jwtHelper: JwtHelperService,
              private links: ListOfLinksService) { }

  public SaveAccount(account: IAccount): Observable<boolean>{
    return this.http.post<ServerMessageWithToken>(this.baseurl + "account/create", account)
      .pipe(tap(message=>{
        if(account){
          this.SetTokens(message.token, message.refreshToken);
        }
      }),map(message => {
        if(message.message==="Аккаунт создан"){
          this.accountService.account = account;
        return true
      }else if(message.message==="Аккаунт с таким эмайлом уже существует"){
        return false
      }}))
  }
  public Competition(){

  }

  public ObjectIsMassege(object: object): object is ServerMessage{
    return "message" in object;
  }
  public UpdateAccount(acc: IAccountChanging){
    return this.http.post<AccountMassege | ServerMessage>(this.baseurl + "account/editing", acc).pipe(map(
      (accOrMess)=>{
        if(this.ObjectIsMassege(accOrMess)){
          return "Неверный пароль"
        }else{
          this.accountService.account = accOrMess.account;
          return "Аккаунт успешно изменён"
        }
      }
    ))
  }

  public GetAccountByToken(){
    this.http.post<{account: IAccount}>(this.baseurl+ "account/getAccount", {ExpiredToken: localStorage.getItem(ACCESS_TOKEN_KEY),
      RefreshToken: localStorage.getItem(REFRESH_TOKEN)}).pipe(map((acc)=>{
      this.accountService.account = acc.account;
      return of(true)
    })).subscribe(bool=> console.log(bool));
  }
 public IsExp(): boolean{
    let token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return this.jwtHelper.isTokenExpired(token);
 }
  public IsInAccount(): boolean{
    let token = localStorage.getItem(ACCESS_TOKEN_KEY);
    if(token && this.jwtHelper.isTokenExpired(token)){
      this.RefreshToken();
      return true;
    }
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  public SetTokens(newToken: string, refreshToken: string){
    localStorage.setItem(ACCESS_TOKEN_KEY, newToken);
    localStorage.setItem(REFRESH_TOKEN, refreshToken);
  }
  public DeleteTokens(){
    localStorage.removeItem(ACCESS_TOKEN_KEY);
  }
  public InAccountToolBar(){
    this.links.listOfLinks = [];
    this.links.listOfLinks.push(this.links.out, this.links.update)
  }
  public OutAccountToolBar(){
    this.links.listOfLinks = [];
    this.links.listOfLinks.push(this.links.in, this.links.create)
  }
 public RefreshToken(): void{
    console.log("Рефреш ")
    this.http.post<RefreshToken>(this.baseurl+ "account/newToken", {ExpiredToken: localStorage.getItem(ACCESS_TOKEN_KEY),
    RefreshToken: localStorage.getItem(REFRESH_TOKEN)}).pipe(tap(tokenObject=>{
      this.SetTokens(tokenObject.newToken, tokenObject.refreshToken);
    })).subscribe(bool=> console.log())
 }
public SendImage(image: FormData){
    this.http.post<ServerMessage>(this.baseurl+ "account/image", image)
}

  public Login(password: string, email: string): Observable<boolean> {
    return this.http.post<RefreshToken>(this.baseurl + "account/login",
      {password: password, email: email}).pipe(
      map(message => {
          if(message.newToken !== "non"){
            this.accountService.account = message._account;
            this.SetTokens(message.newToken, message.refreshToken); return true;
          }
        return false;
      })
    )
  }

  public LikePost(id: number, likes: number): Observable<boolean> {
    let post = {id: id, likes: likes}
    return this.http.post<ServerMessage>(this.baseurl + "post/like", post).pipe(map(s=>{
      console.log(s.message);
      return s.message === "Успешно";
    }))
  }

  public FetchAllPosts(): Promise<any>{
    return fetch(this.baseurl + "post/fetchAll", {method: "GET"})
  }

  public CreatePost(post: FormData): Promise<any> {
    return fetch(this.baseurl + "post/create", {method: "POST", body: post});
  }
}


