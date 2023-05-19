import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemsReactiveComponent } from './items-reactive.component';

describe('ItemsReactiveComponent', () => {
  let component: ItemsReactiveComponent;
  let fixture: ComponentFixture<ItemsReactiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemsReactiveComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemsReactiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
