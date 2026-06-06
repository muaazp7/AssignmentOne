import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventsHome } from './events-home';

describe('EventsHome', () => {
  let component: EventsHome;
  let fixture: ComponentFixture<EventsHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EventsHome],
    }).compileComponents();

    fixture = TestBed.createComponent(EventsHome);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
