import {Injectable} from '@angular/core';
import {MetaData, SingleMeta} from "../_models/MetaData";

declare var singleMeta: SingleMeta;

@Injectable({
  providedIn: 'root'
})
export class MetaService
{
  get CurrentMeta (): SingleMeta
  {
    return this._CurrentMeta;
  }

  private MetaData: MetaData
  private readonly _CurrentMeta: SingleMeta

  constructor ()
  {
    this._CurrentMeta = singleMeta;
    console.log(this._CurrentMeta, this.MetaData)
  }

}
