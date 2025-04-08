Unit Dcl_CTV;

Interface
const
     cmax=3;
     Mkd=8;  {max кол-во долгов}
     Mnp=5;   {max число провторений 1 примера}
     N_raz=8; {общее к-во примеров в разделе}
     fres ='files\Merite';
     mva:array[1..12] of string
          =('Прямая через регистр        RN           ',
            'Прямая с автоувеличением    (RN)+        ',
            'Прямая с автоуменьшением    -(RN)        ',
            'Индексация                  E(RN)        ',
            'Косвенная через регистр     (RN) или @RN ',
            'Косвенная с автоувеличением @(RN)+       ',
            'Косвенная с автоуменьшением @-(RN)       ',
            'Косвенная индексация        @E(RN)       ',
            'Непосредственная            #E           ',
            'Абсолютная                  @#E          ',
            'Относительная               E            ',
            'Относительно-косвенная      @E           ');
type
     t_res = record
            ident : string[24];
            mer   : array[1..12] of char;
            exit  : byte;
            dolg  : array[1..Mkd] of longint;
            kd    : byte;
            prim  : longint;
            razd  : byte;
            end;
var
   fo     : file of t_Res;
   res    : t_Res;
Implementation
end.
