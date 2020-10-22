import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { PuzzleServ } from './Service/PuzzleService';
import { PuzzleReq } from './Service/PuzzleReq';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent 
{
  postData = {
    test: 'My content',
  }
  
  url = 'http://localhost:52871/api/getpuzzle';
 /* data{
    image: base64_
  }*/

  selectedFile = null;
  /*constructor(private http: HttpClient){
    
  }*/
  constructor(private httpService: PuzzleServ){}
  OnFileSelected(event){
    this.selectedFile = event.target.file[0];
  }

  OnGetPuzzle()
  {
    var fileUplodVM: PuzzleReq=
    {
      Id:1,
 //     BImage:this.selectedFile.toString(),
      HeightRect:200,
      WidthRect:200
    };

    /*const fd = new FormData();
    if(this.selectedFile==null)
    {
      alert("Please select file");
    }
    else
    {     
     
    } */ 

    console.log(this.httpService.GetPuzzle(fileUplodVM).subscribe());
    /*fd.append('image', this.selectedFile,this.selectedFile.name);*/
    /*this.http.post(this.url,fileUplodVM).toPromise().then(data =>
    {
      console.log(data);
    })*/
  }; 
}




