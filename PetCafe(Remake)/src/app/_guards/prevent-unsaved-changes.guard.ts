import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { PuppyEditComponent } from '../components/pages/puppy-edit/puppy-edit.component';

@Injectable({
    providedIn: 'root'
  })
  export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {

    canDeactivate(component:  PuppyEditComponent): boolean {
      if (component.editForm.dirty){
        return confirm("are you want to leave? any changes will not be saved");
      }
      return true;
    }
  }
