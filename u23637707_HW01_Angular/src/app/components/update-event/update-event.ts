import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Service } from '../../services/service';

@Component({
  selector: 'app-update-event',
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './update-event.html',
  styleUrl: './update-event.scss',
})
export class UpdateEvent implements OnInit {
  eventData: any = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: Service,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.loadEvent(id);
      }
    });
  }

  loadEvent(id: string): void {
    this.eventData = null;
    this.service.fetchEventById(id).subscribe({
      next: (data) => {
        this.eventData = data;
        this.cdr.detectChanges();
      },
      error: (err) => console.error('Failed to load event', err)
    });
  }

  saveChanges(): void {
    this.service.modifyEvent(this.eventData.event_Id, this.eventData).subscribe({
      next: () => this.router.navigate(['/home']),
      error: (err) => console.error('Failed to update event', err)
    });
  }

  discard(): void {
    this.router.navigate(['/home']);
  }
}