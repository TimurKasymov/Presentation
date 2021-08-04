import {Injectable, OnDestroy, OnInit} from '@angular/core';
import {IAccount} from "./interfaces.service";
import {Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AccountRepositoryService {

  public item: number = 0;
  constructor() {
  }

  public IsAccountNull(): boolean{
    return this.account === null
  }
  public account:IAccount;

}
