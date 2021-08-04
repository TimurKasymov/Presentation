import {Route} from "@angular/router";
import {CreateAccountComponent} from "../../create-account/create-account.component";
import {UpdateAccountComponent} from "../update-account/update-account.component";
import {InAccountComponent} from "../in-account/in-account.component";
import {PostCreationComponent} from "../post-creation/post-creation.component";
import {SharedPostsComponent} from "../shared-posts/shared-posts.component";
import {InjectionToken} from "@angular/core";

export const routsInAcount: Route[] =
  [  {
    path: "update",
    component: UpdateAccountComponent,
     },
    {
      path: "home",
      component: InAccountComponent,
    },
    {
      path: "createPost",
      component: PostCreationComponent,
    },
    {
      path: "allPosts",
      component: SharedPostsComponent,
    },
]

