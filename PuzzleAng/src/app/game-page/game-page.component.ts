import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-game-page',
  templateUrl: './game-page.component.html',
  styleUrls: ['./game-page.component.css']
})
export class GamePageComponent implements OnInit {


  constructor() { }

  ngOnInit(): void {
  }

  btnClass: string = 'btnDown';
  btnFlag: boolean = false;
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

}
