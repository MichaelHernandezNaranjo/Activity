import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name:"truncate"
})
export class TruncatePipe implements PipeTransform{
  transform(value:string | null, limite:number) : string{
    let res : string = value == null ? "" : value;
    return res.length > limite ? res.substring(0,limite)+"..." :   res;
  }
}