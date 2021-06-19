import "@angular/compiler";
import {
  AfterViewInit,
  Compiler,
  Component,
  Input, NgModule,
  OnInit,
  ViewChild,
  ViewContainerRef
} from '@angular/core';
import {SingleMeta} from "../_models/MetaData";
import {MetaService} from "../_services/meta.service";
import {HomeComponent} from "../home/home.component";

@Component({
  selector: 'holo-deck',
  templateUrl: './holo-deck.component.html',
  styleUrls: ['./holo-deck.component.css']
})
export class HoloDeckComponent<T> implements OnInit, AfterViewInit
{
  // @Input() Parent = Object.getPrototypeOf(HomeComponent).constructor;

  private readonly Meta: SingleMeta;
  private readonly Template: string;

  @ViewChild(
    'container',
    {read: ViewContainerRef, static: false}
  ) container: ViewContainerRef;

  constructor (private metaService: MetaService, private compiler: Compiler)
  {
    if (this.Meta == null)
    {
      this.Meta = metaService.CurrentMeta;
    }

    console.log("[holo-deck] meta ->", this.Meta);

    this.Template = this.Meta.Template;

    console.log("[holo-deck] template ->", this.Template);
  }

  ngOnInit (): void
  {
  }

  ngAfterViewInit (): void
  {
    let component = Component({
      template: this.Template,
      styles: [':host {color: red}']
    })(// @ts-ignore
      class extends this.Parent
    {
    });

    let module = NgModule({declarations: [component]})(class
    {
    });

    this.compiler.compileModuleAndAllComponentsAsync(module).then(factories =>
    {
      // Get the component factory.
      const componentFactory = factories.componentFactories[0];
      // Create the component and add to the view.
      this.container.createComponent(componentFactory);
    })

  }
}
