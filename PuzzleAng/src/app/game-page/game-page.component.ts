import { Component, OnInit } from '@angular/core';
import { PuzzleServ } from '../Service/PuzzleService';
import { PuzzleReq } from '../Service/PuzzleReq';
import { PuzzleResp } from '../Service/PuzzleResp';

@Component({
  selector: 'app-game-page',
  templateUrl: './game-page.component.html',
  styleUrls: ['./game-page.component.css']
})
export class GamePageComponent implements OnInit {


  constructor(private httpService: PuzzleServ){}

  ngOnInit(): void {
  }

  btnClass: string = 'btnDown';
  btnFlag: boolean = false;
  arr= Array;

  onclick(){
      if(this.btnFlag){
        this.btnFlag = false;
        this.btnClass = 'btnUp';
      }
      else{
        this.btnFlag = true;
        this.btnClass = 'btnDown';
      }
  }

  imageError: string;
  imageName: string;
  isImageSaved: boolean;
  cardImageBase64: string;

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

    puzzleImg: PuzzleResp ;

    OnGetPuzzle()
    {
      var fileUplodVM: PuzzleReq =
      {
        Id:1,
        BImage: this.cardImageBase64,
        HeightRect:200,
        WidthRect:200,
        NameImage: this.imageName
      };
  
      this.puzzleImg = this.httpService.GetPuzzle(fileUplodVM);
    };

    flag: boolean = false;
    firstIndex: number;
    iY:number;
    IsCheckImageBox: boolean;
    activeImg: string; 
    statusClass = 'not-active';
    image1: string;
    image2: string;

    public changedPuzzle(index: number){
      if(this.flag == false){
        this.image1 = this.puzzleImg.imageLst[index];
        this.image2 = null;
        this.firstIndex = index;
        this.flag = true;
  
  
      }
      else{
        this.image2 = this.puzzleImg.imageLst[index];
        this.puzzleImg.imageLst[this.firstIndex] = this.image2;
        this.puzzleImg.imageLst[index] = this.image1;
        this.flag = false;
      }
  
      this.ChangeStyleImg(this.flag,this.firstIndex);
    }
  
    private ChangeStyleImg(flag: boolean, index: number){
      if(flag == true){
        (<HTMLImageElement>document.getElementById('puzz_' + index)).style.border = '3px solid transparent';
        (<HTMLImageElement>document.getElementById('puzz_' + index)).style.borderColor = 'green';
      }
      else{
        (<HTMLImageElement>document.getElementById('puzz_' + index)).style.border = '0px';
        (<HTMLImageElement>document.getElementById('puzz_' + index)).style.borderColor = 'none';

      }
    }
  
}
