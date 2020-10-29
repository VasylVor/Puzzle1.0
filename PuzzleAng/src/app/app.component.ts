import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { PuzzleServ } from './Service/PuzzleService';
import { PuzzleReq } from './Service/PuzzleReq';
import { PuzzleResp } from './Service/PuzzleResp';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent 
{
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;
  puzzleImg: PuzzleResp;
  imageName: string;
  img: string = "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";
  constructor(private httpService: PuzzleServ){}

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
        this.imageName = fileInput.target.files[0].name;
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
      WidthRect:200,
      NameImage: this.imageName
    };

    this.puzzleImg = this.httpService.GetPuzzle(fileUplodVM);
    console.log(this.puzzleImg.name);
    
  }; 
}




