import {Injectable, OnInit} from '@angular/core';
import {Subject} from "rxjs";
import {DrawerStuffBox, IDrawerStuffBox} from "./DrawerStuufBox";

@Injectable({
  providedIn: 'root'
})
export class DrawerFeedService{

  constructor() { }
  //public $drawerFeed: Subject<IDrawerStuffBox[]> = new Subject<IDrawerStuffBox[]>();
  public $needSupply: Subject<boolean> = new Subject<boolean>();
  public on: boolean = false

  StartSubscription(): void {
    this.$needSupply.subscribe({
      next: (b)=>{
        this.on = b;
      }
    }
    )
  }
}
