import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {PuzzleReq} from './PuzzleReq';

@Injectable({
    providedIn: 'root'
  })
export class PuzzleServ{
    constructor(private http: HttpClient){}
    url = 'http://localhost:52871/api/CreatePuzzle';

    GetPuzzle(puzzleReq: PuzzleReq){
        const req = {id: puzzleReq.Id, heightR: puzzleReq.HeightRect, weidth: puzzleReq.WidthRect};
        return this.http.post(this.url ,req);
    }
}