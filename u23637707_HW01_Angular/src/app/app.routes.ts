import { Routes } from '@angular/router';
import { EventsHome } from './components/events-home/events-home';
import { CreateEvent } from './components/create-event/create-event';
import { UpdateEvent } from './components/update-event/update-event';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: EventsHome },
  { path: 'create-event', component: CreateEvent },
  { path: 'update-event/:id', component: UpdateEvent },
];