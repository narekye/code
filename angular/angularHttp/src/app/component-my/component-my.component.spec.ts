import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentMyComponent } from './component-my.component';

describe('ComponentMyComponent', () => {
  let component: ComponentMyComponent;
  let fixture: ComponentFixture<ComponentMyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComponentMyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComponentMyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
