import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HoloDeckComponent } from './holo-deck.component';

describe('HoloDeckComponent', () => {
  let component: HoloDeckComponent;
  let fixture: ComponentFixture<HoloDeckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HoloDeckComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HoloDeckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
