import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpServiceService} from "../shared/http-service.service";
import {IAccount} from "../shared/interfaces.service";
import {Router} from "@angular/router";
import {AccountRepositoryService} from "../shared/account-repository.service";
import {Observable} from "rxjs";


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private http: HttpServiceService, private router: Router,
              public accountRepository: AccountRepositoryService) {
  }

  public IsNotAuthenticated: boolean = false;

  ngOnInit() {
  }

  public AccountForm: FormGroup = new FormGroup({
    Password: new FormControl("", Validators.required),
    Email: new FormControl("", [Validators.required, Validators.email]),
  })

  public Login() {
    var account: Observable<boolean> = this.http.Login(this.AccountForm.value.Password, this.AccountForm.value.Email)
    account.subscribe(foundAcc => {
      if(foundAcc){
        this.router.navigate(["PersonalAccount"]).then()
      } else {
        this.IsNotAuthenticated = true;
      }
    })
  }
}
