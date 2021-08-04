import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {ListOfLinksService} from "./shared/list-of-links.service";
import {HttpServiceService} from "./shared/http-service.service";
import {AccountRepositoryService} from "./shared/account-repository.service";
import {DrawerFeedService} from "./shared/drawer-feed.service";
import {DrawerStuffBox} from "./shared/DrawerStuufBox";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  encapsulation : ViewEncapsulation.None,

})
export class AppComponent implements OnInit{
  constructor(public ListOfLinks: ListOfLinksService,
              public http:HttpServiceService,
              public account: AccountRepositoryService,
              public DrawerFeed: DrawerFeedService) {
  }

  public drawerFeedBox = DrawerStuffBox;

  ngOnInit(): void {
    this.DrawerFeed.StartSubscription()
  }

}
