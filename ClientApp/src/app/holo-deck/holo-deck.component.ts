import "@angular/compiler";
import {
  AfterViewInit,
  Compiler,
  Component,
  ComponentFactoryResolver,
  Input, NgModule,
  OnInit,
  TemplateRef, ViewChild,
  ViewContainerRef
} from '@angular/core';
import {SingleMeta} from "../_models/MetaData";
import {MetaService} from "../_services/meta.service";

@Component({
  selector: 'holo-deck',
  templateUrl: './holo-deck.component.html',
  styleUrls: ['./holo-deck.component.css']
})
export class HoloDeckComponent implements OnInit, AfterViewInit
{
  @ViewChild(
    'container',
    {read: ViewContainerRef, static: false}
  ) container: ViewContainerRef;

  constructor (private compiler: Compiler)
  {
  }

  // constructor (private metaService: MetaService, private componentFactoryResolver: ComponentFactoryResolver)
  // {
  //   // if (this.Meta == null)
  //   // {
  //   //   this.Meta = metaService.CurrentMeta;
  //   // }
  //   //
  //   // console.log("[holo-deck] meta ->", this.Meta);
  //   //
  //   // this.Template = this.Meta.Template;
  //   //
  //   // console.log("[holo-deck] template ->", this.Template);
  // }

  ngOnInit (): void
  {
  }

  ngAfterViewInit (): void
  {
    let component = Component({
      template: '<div>Test value: {{test}}</div>',
      styles: [':host {color: red}']
    })(class
    {
      test = 'some value';
    });

    let module = NgModule({declarations: [component]})(class {});

    this.compiler.compileModuleAndAllComponentsAsync(module).then(factories => {
      // Get the component factory.
      const componentFactory = factories.componentFactories[0];
      // Create the component and add to the view.
      this.container.createComponent(componentFactory);
    })

  }
}
