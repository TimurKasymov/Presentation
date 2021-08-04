import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router} from '@angular/router';
import {Observable, of} from 'rxjs';
import {map} from "rxjs/operators";
import {CreateAccountComponent} from "../create-account/create-account.component";
import {ACCESS_TOKEN_KEY, HttpServiceService} from "./http-service.service";
import {AccountRepositoryService} from "./account-repository.service";
import {DrawerFeedService} from "./drawer-feed.service";

@Injectable({
  providedIn: 'root'
})
export class GuarderGuard implements CanActivate {
  constructor(private router: Router,
              private http: HttpServiceService,
              private acc: AccountRepositoryService,
              private  drawerFeed: DrawerFeedService ) {
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
    if(this.http.IsInAccount()){
      this.drawerFeed.$needSupply.next(true);
      this.http.GetAccountByToken();
      this.http.InAccountToolBar()
      return of(true)
    }
  }
}

@Injectable({
  providedIn: 'root'
})
export class GuarderLogout implements CanActivate {
  constructor(private router: Router,
              private http: HttpServiceService,
              private drawerFeed: DrawerFeedService,
              private acc: AccountRepositoryService) {
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
    this.drawerFeed.on = false;
    this.http.DeleteTokens();
    this.http.OutAccountToolBar();
    this.acc.account = null;
    console.log(Boolean(localStorage.getItem(ACCESS_TOKEN_KEY)));
    return of(true)
  }
}

@Injectable({
  providedIn: 'root'
})
export class GuarderLogin implements CanActivate {
  constructor(private router: Router,
              private http: HttpServiceService) {
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> {
    if(this.http.IsInAccount()){
      this.router.navigate(["PersonalAccount"]).then()
      return of(false)
    }else {
      return of(true)
    }
  }
}
