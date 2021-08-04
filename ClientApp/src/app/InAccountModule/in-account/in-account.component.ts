import {AfterViewInit, Component, EventEmitter, OnDestroy, OnInit, Output} from '@angular/core';
import {AccountRepositoryService} from "../../shared/account-repository.service";
import {HttpServiceService} from "../../shared/http-service.service";
import {DrawerFeedService} from "../../shared/drawer-feed.service";

@Component({
  selector: 'app-in-account',
  templateUrl: './in-account.component.html',
  styleUrls: ['./in-account.component.css']
})
export class InAccountComponent implements OnDestroy, OnInit {

  constructor(private acc: AccountRepositoryService,
              private httpService:  HttpServiceService,
              private  drawerFeed: DrawerFeedService ) { }


  ngOnDestroy(): void {
    this.httpService.OutAccountToolBar()
  }

  ngOnInit(): void {
    this.drawerFeed.$needSupply.next(true);

  }


}
