import { Pipe, PipeTransform } from '@angular/core';


@Pipe({ name: 'cusCurrencyPipe' })
export class CustomCurrencyPipeModule implements PipeTransform 
{
  transform(price: string) {
    if (price !== undefined && price !== null) 
      return price.replace(/,/g, "");
    }
}
