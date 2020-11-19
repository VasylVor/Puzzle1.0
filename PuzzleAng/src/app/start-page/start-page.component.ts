import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-start-page',
  templateUrl: './start-page.component.html',
  styleUrls: ['./start-page.component.css']
})
export class StartPageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Output() playFlag = new EventEmitter<boolean>();
  clickPlay(playFlag:any){
    this.playFlag.emit(playFlag);
  }
}
