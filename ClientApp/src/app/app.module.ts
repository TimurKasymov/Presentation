import { BrowserModule } from '@angular/platform-browser';
import { NgModule, InjectionToken } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CreateAccountComponent } from './create-account/create-account.component';
import {SharedModule} from "./shared/shared.module";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import { ReactiveFormsModule } from '@angular/forms';
import {ErrorEmailComponent} from "./create-account/error-email/error-email.component";
import {LoginComponent} from "./login/login.component";
import {routs} from "./shared/routs.service";
import {environment} from "../environments/environment";
import {JwtModule} from "@auth0/angular-jwt";
import {ACCESS_TOKEN_KEY} from "./shared/http-service.service";




@NgModule({
  declarations: [
    AppComponent,
    CreateAccountComponent,
    ErrorEmailComponent,
    LoginComponent,
  ],
  entryComponents: [ErrorEmailComponent],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    SharedModule,
    RouterModule.forRoot(routs),
    BrowserAnimationsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter:() => {
          return localStorage.getItem(ACCESS_TOKEN_KEY); },
        allowedDomains: ['localhost:5001']
      }
    }),
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
