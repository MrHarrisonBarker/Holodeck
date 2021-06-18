import { Component } from '@angular/core';
import {MetaService} from "./_services/meta.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  constructor (private metaService: MetaService)
  {
  }

  getMeta ()
  {
    console.log(this.metaService.CurrentMeta);
  }
}
