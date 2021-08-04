import {Component, Inject, OnInit} from '@angular/core';
import {HttpServiceService} from "../../shared/http-service.service";
import {IPost} from "../../shared/interfaces.service";
import {filter} from "rxjs/operators";
import {} from "../in-account-module/in-account-module.module";
import {urlInRoot} from "../../shared/shared.module";

@Component({
  selector: 'app-shared-posts',
  templateUrl: './shared-posts.component.html',
  styleUrls: ['./shared-posts.component.css']
})
export class SharedPostsComponent implements OnInit {

  constructor(private http: HttpServiceService,
              @Inject(urlInRoot) public url) {
  }

  public posts: IPost[];

  public Like(post: IPost){
    let i = this.posts.indexOf(post);
    post.likes += 1;
    this.posts[i] = post;
    this.http.LikePost(post.id, post.likes).subscribe(b => {
      if(!b){console.log("Ошибка: like")}
    })
  }

  ngOnInit() {
    this.http.FetchAllPosts().then(accs => accs.json().then(accs => {
        console.log(accs["posts"]);
        if (accs["posts"]) {
          this.posts = accs["posts"];
          console.log(this.posts[0])
        }
      })
    )
  }
}
