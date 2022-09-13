import { Model } from 'pinia-orm'
import { Attr, Str } from 'pinia-orm/dist/decorators'

export class Publisher extends Model {
    static entity = 'publishers';

    @Attr(null)
    declare id: string | null;

    @Str('')
    declare name: string;
}