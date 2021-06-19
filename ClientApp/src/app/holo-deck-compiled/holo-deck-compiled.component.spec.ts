import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HoloDeckCompiledComponent } from './holo-deck-compiled.component';

describe('HoloDeckCompiledComponent', () => {
  let component: HoloDeckCompiledComponent;
  let fixture: ComponentFixture<HoloDeckCompiledComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HoloDeckCompiledComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HoloDeckCompiledComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
