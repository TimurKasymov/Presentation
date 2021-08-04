import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {HttpServiceService} from "../../shared/http-service.service";
import {AccountRepositoryService} from "../../shared/account-repository.service";

@Component({
  selector: 'app-post-creation',
  templateUrl: './post-creation.component.html',
  styleUrls: ['./post-creation.component.css']
})
export class PostCreationComponent implements OnInit {

  constructor(
    private http: HttpServiceService,
    private acc: AccountRepositoryService
  ) { }

  public PostGroup: FormGroup = new FormGroup({
    file: new FormControl("", [Validators.required]),
    title: new FormControl("", [Validators.required]),
    text:  new FormControl("", [Validators.required])
  })
public complete: boolean = true;

  public CreatePostInC(): void{
    const selectedFile = <HTMLInputElement>document.getElementById('input');
    const selectedimage = selectedFile.files[0];
    const uploadData = new FormData();
    console.log(this.acc.account['Email'], this.acc.account)
    uploadData.append('Picture', selectedimage, selectedimage.name);
    uploadData.append("title", this.PostGroup.value.title)
    uploadData.append("text", this.PostGroup.value.text)
    uploadData.append("email", this.acc.account['email'])
    uploadData.append("password", this.acc.account['password'])
    this.http.CreatePost(uploadData).then(
      message => {(message.json().then(m => {console.log(m["message"])
        if(m["message"] === "Успешно"){

        this.complete = false;
      }})) }
    );
  }

  ngOnInit() {
  }

}
