import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { DragDropModule} from '@angular/cdk/drag-drop';
import { LoadPuzzlesComponent } from './load-puzzles/load-puzzles.component';
import { PuzzleComponent } from './puzzle/puzzle.component';
import { ImageComponent } from './image/image.component';
import { StartPageComponent } from './start-page/start-page.component';




@NgModule({
  declarations: [
    AppComponent,
    LoadPuzzlesComponent,
    PuzzleComponent,
    ImageComponent,
    StartPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatTableModule,
    DragDropModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
