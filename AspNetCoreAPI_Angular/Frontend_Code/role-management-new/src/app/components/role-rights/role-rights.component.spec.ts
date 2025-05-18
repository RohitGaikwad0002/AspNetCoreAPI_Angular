import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoleRightsComponent } from './role-rights.component';

describe('RoleRightsComponent', () => {
  let component: RoleRightsComponent;
  let fixture: ComponentFixture<RoleRightsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RoleRightsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RoleRightsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
