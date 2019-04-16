import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThreadListingComponent } from './thread-listing.component';

describe('ThreadListingComponent', () => {
  let component: ThreadListingComponent;
  let fixture: ComponentFixture<ThreadListingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThreadListingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThreadListingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
