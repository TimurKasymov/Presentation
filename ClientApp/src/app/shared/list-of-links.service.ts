import { Injectable } from '@angular/core';
import {IlistOfLinks} from "./interfaces.service";

@Injectable({
  providedIn: 'root'
})

export class ListOfLinksService {

  public in = {
    name: "Войти",
    url: "/login",
    icon: "login"
  }

public out = {
  name: "Выйти",
  url: "/logout",
  icon: "logout"
}

public create = {
  name: "Создать аккаунт",
  url: "/createAccount",
  icon: "person",
}

public update = {
  name: "Изменить аккаунт",
  url: "PersonalAccount/update",
  icon: "update icon",
}
  public listOfLinks: IlistOfLinks[] = [
     {
       name: "Создать аккаунт",
       url: "/createAccount",
       icon: "person",
     },
    {
      name: "Войти",
      url: "/login",
      icon: "login"
    },
   ]
  constructor() { }
}


