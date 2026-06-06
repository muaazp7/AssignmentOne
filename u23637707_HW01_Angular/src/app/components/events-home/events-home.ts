import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Service } from '../../services/service';

@Component({
  selector: 'app-events-home',
  imports: [CommonModule, RouterModule],
  templateUrl: './events-home.html',
  styleUrl: './events-home.scss',
})
export class EventsHome implements OnInit {
  campusEvents: any[] = [];

  constructor(private router: Router, private service: Service, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.loadAllEvents();
  }

  loadAllEvents(): void {
    this.service.fetchEvents().subscribe({
      next: (data) => {
        this.campusEvents = [...data];
        this.cdr.detectChanges();
      },
      error: (err) => console.error('Failed to fetch events', err)
    });
  }

  goToUpdate(id: string): void {
    this.router.navigate(['/update-event', id]);
  }

  deleteEvent(id: string): void {
    this.service.removeEvent(id).subscribe({
      next: () => this.loadAllEvents(),
      error: (err) => console.error('Failed to delete event', err)
    });
  }
}