import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Service } from '../../services/service';

@Component({
  selector: 'app-create-event',
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './create-event.html',
  styleUrl: './create-event.scss',
})
export class CreateEvent {
  newEvent = {
    title: '',
    location: '',
    ticketPricing: null
  };

  constructor(private router: Router, private service: Service) {}

  isValid(): boolean {
    return this.newEvent.title.trim() !== '' &&
           this.newEvent.location.trim() !== '' &&
           this.newEvent.ticketPricing !== null;
  }

  submitEvent(): void {
    this.service.createEvent(this.newEvent).subscribe({
      next: () => this.router.navigate(['/home']),
      error: (err) => console.error('Failed to create event', err)
    });
  }

  goBack(): void {
    this.router.navigate(['/home']);
  }
}