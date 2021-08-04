import {Component, ElementRef, OnInit, ViewChild, DoCheck} from '@angular/core';
import {AbstractControl, EmailValidator, FormControl, FormGroup, Validators} from "@angular/forms";
import {IAccount} from "../shared/interfaces.service";
import {ACCESS_TOKEN_KEY, HttpServiceService} from "../shared/http-service.service";
import {MatSnackBar} from '@angular/material/snack-bar';
import {ErrorEmailComponent} from "./error-email/error-email.component";
import {Observable} from "rxjs";
import {Router} from "@angular/router";


@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit{

  constructor(private HttpService: HttpServiceService, private _snackBar: MatSnackBar, private route: Router) { }


  public CreateForm(event: FormGroup){
    console.log(event.controls);
  }

  openSnackBar() {
    this._snackBar.openFromComponent(ErrorEmailComponent, {
      duration: 1000,
    })}

  ngOnInit() {

  }
  public AccountForm: FormGroup = new FormGroup({
    Name: new FormControl("Tim", [Validators.maxLength(100), Validators.required]),
    SecondName: new FormControl("Dicloson", [Validators.maxLength(100), Validators.required]),
    About: new FormControl("I am a pingvin", [Validators.maxLength(1000)]),
    Password: new FormControl("", [Validators.minLength(8), Validators.required]),
    PasswordA:  new FormControl("", [Validators.minLength(8), Validators.required]),
    Email: new FormControl("", [Validators.email, Validators.required]),
    Role: new FormControl("", Validators.required)
  })


  public SignIn() {
    let account: IAccount = {
      About: this.AccountForm.value.About, Email: this.AccountForm.value.Email,
      Name:  this.AccountForm.value.Name, Password: this.AccountForm.value.Password,
      Surname: this.AccountForm.value.SecondName,
      Role: Number(this.AccountForm.value.Role),
      Posts: []
    }
    let accountExisting: Observable<boolean> = this.HttpService.SaveAccount(account);
    accountExisting.subscribe((serverMessage)=>{
      if(!serverMessage){
        this.openSnackBar();
      }else{
        this.route.navigate(["PersonalAccount"]).then();
      }
    })

  }
}
