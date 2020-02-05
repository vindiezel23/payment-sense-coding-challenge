import { Currency } from './currency';
import { Language } from './language';

export interface Country {
  alpha3Code: string;
  name: string;
  flag: string;
  population: number;
  timezones: string[];
  currencies: Currency[];
  languages: Language[];
}
