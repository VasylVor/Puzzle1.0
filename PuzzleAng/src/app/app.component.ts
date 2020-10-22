import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  postData = {
    test: 'My content',
  }
  
  url = 'http://localhost:52871/api/getpuzzle';
 /* data{
    image: base64_
  }*/
  
  constructor(private http: HttpClient){
    this.http.get(this.url).toPromise().then(data =>{
      console.log(data);
    });

    /*OnFileSelected(event){

    }*/
  }
}
