/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PetalojsComponent } from './petalojs.component';

describe('PetalojsComponent', () => {
  let component: PetalojsComponent;
  let fixture: ComponentFixture<PetalojsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PetalojsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PetalojsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
