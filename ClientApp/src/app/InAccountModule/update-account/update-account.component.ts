import {AfterContentInit, AfterViewInit, Component, OnInit} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {AccountRepositoryService} from "../../shared/account-repository.service";
import {IAccount, IAccountChanging} from "../../shared/interfaces.service";
import {Observable, of, pipe} from "rxjs";
import {HttpServiceService} from "../../shared/http-service.service";
import {ErrorEmailComponent} from "../../create-account/error-email/error-email.component";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-update-account',
  templateUrl: './update-account.component.html',
  styleUrls: ['./update-account.component.css']
})
export class UpdateAccountComponent implements OnInit {


  constructor(private acc: AccountRepositoryService,
              private HttpService: HttpServiceService,
              private _snackBar: MatSnackBar) { }

  public accountIsChenged: String;

  ngOnInit() {

  }


  public AccountForm: FormGroup = new FormGroup({
    Name: new FormControl(this.acc.account['name'], [Validators.maxLength(100), Validators.required]),
    Surname: new FormControl(this.acc.account['surname'], [Validators.maxLength(100), Validators.required]),
    About: new FormControl(this.acc.account['about'], [Validators.maxLength(1000)]),
    Password: new FormControl("", [Validators.minLength(8), Validators.required]),
    PastPassword: new FormControl("", [Validators.minLength(8), Validators.required]),
  })
  openSnackBar(message: string) {
    this._snackBar.open(message, "обновление", {
      duration: 2000,
    })}
  public SignIn() {
    console.log("Сайн ин")
    this.AccountForm.addControl("Email", new FormControl(this.acc.account['email'], [Validators.required]));
    let accountExisting: Observable<string> = this.HttpService.UpdateAccount(this.AccountForm.value);
    accountExisting.subscribe((serverMessage)=>{
      if(serverMessage === "Неверный пароль"){
        this.openSnackBar(serverMessage);
      }else{
        this.accountIsChenged = serverMessage;
      }
    })

  }
}
