import {Route} from "@angular/router";
import {LoginComponent} from "../login/login.component";
import {CreateAccountComponent} from "../create-account/create-account.component";
import {InAccountModuleModule} from "../InAccountModule/in-account-module/in-account-module.module";
import {GuarderGuard, GuarderLogin, GuarderLogout} from "./guarder.guard";
import {UpdateAccountComponent} from "../InAccountModule/update-account/update-account.component";
import {InAccountComponent} from "../InAccountModule/in-account/in-account.component";



export const routs: Route[] = [
  {
    path: "login",
    canActivate: [GuarderLogin],
    component: LoginComponent
  },
  {
    path: "logout",
    canActivate: [GuarderLogout],
    component: LoginComponent
  },
  {
    path: "createAccount",
    component: CreateAccountComponent
  },  {
    path: "PersonalAccount",
    canActivate: [GuarderGuard],
    loadChildren: ()=>
      import("../InAccountModule/in-account-module/in-account-module.module").then(m=>m.InAccountModuleModule),
  }

]
