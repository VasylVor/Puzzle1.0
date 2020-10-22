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
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;
  /*constructor(private http: HttpClient){
    
  }*/
  constructor(private httpService: PuzzleServ){}
/*  OnFileSelected(event){
    this.cardImageBase64 = event.target.file[0];
  }*/
  OnFileSelected(fileInput: any) {
    this.imageError = null;
    if (fileInput.target.files && fileInput.target.files[0]) {
        // Size Filter Bytes
        const max_size = 20971520;
        const allowed_types = ['image/png', 'image/jpeg'];
        const max_height = 15200;
        const max_width = 25600;

        if (fileInput.target.files[0].size > max_size) {
            this.imageError =
                'Maximum size allowed is ' + max_size / 1000 + 'Mb';

            return false;
        }

        if (!allowed_types.includes(fileInput.target.files[0].type)) {
            this.imageError = 'Only Images are allowed ( JPG | PNG )';
            return false;
        }
        const reader = new FileReader();
        reader.onload = (e: any) => {
            const image = new Image();
            image.src = e.target.result;
            image.onload = rs => {
                const img_height = rs.currentTarget['height'];
                const img_width = rs.currentTarget['width'];

                console.log(img_height, img_width);


                if (img_height > max_height && img_width > max_width) {
                    this.imageError =
                        'Maximum dimentions allowed ' +
                        max_height +
                        '*' +
                        max_width +
                        'px';
                    return false;
                } else {
                    const imgBase64Path = e.target.result;
                    this.cardImageBase64 = imgBase64Path;
                    this.isImageSaved = true;
                    // this.previewImagePath = imgBase64Path;
                }
            };
        };

        reader.readAsDataURL(fileInput.target.files[0]);
    }
}


  OnGetPuzzle()
  {
    var fileUplodVM: PuzzleReq=
    {
      Id:1,
      BImage: this.cardImageBase64,
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




