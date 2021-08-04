import {InjectionToken, NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from "@angular/router";
import {InAccountComponent} from "../in-account/in-account.component";
import {SharedModule} from "../../shared/shared.module";
import {UpdateAccountComponent} from "../update-account/update-account.component";
import {JwtModule} from "@auth0/angular-jwt";
import {ACCESS_TOKEN_KEY} from "../../shared/http-service.service";
import {environment} from "../../../environments/environment";
import {routsInAcount} from "./routs";
import {PostCreationComponent} from "../post-creation/post-creation.component";
import {SharedPostsComponent} from "../shared-posts/shared-posts.component";



@NgModule({
  declarations: [InAccountComponent,
    UpdateAccountComponent,
    PostCreationComponent,
    SharedPostsComponent],

  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routsInAcount)
  ]
})
export class InAccountModuleModule { }
