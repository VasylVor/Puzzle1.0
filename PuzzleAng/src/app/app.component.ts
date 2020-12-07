import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { PuzzleServ } from './Service/PuzzleService';
import { PuzzleReq } from './Service/PuzzleReq';
import { PuzzleResp } from './Service/PuzzleResp';
import {StartPageComponent} from './start-page/start-page.component';
import {CdkDragDrop, moveItemInArray,transferArrayItem} from '@angular/cdk/drag-drop';
import { GamePageComponent } from './game-page/game-page.component';
0

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent 
{
  constructor(private httpService: PuzzleServ){}

  nextPage:boolean = true;

    clickPlay(playFlag:any){
      this.nextPage = playFlag;
    }
}




