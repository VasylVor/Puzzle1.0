import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoadPuzzlesComponent } from './load-puzzles.component';

describe('LoadPuzzlesComponent', () => {
  let component: LoadPuzzlesComponent;
  let fixture: ComponentFixture<LoadPuzzlesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoadPuzzlesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoadPuzzlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
