.model tiny

.data
    num dw 2
.code

N:
    push cs
    push ds
    
;;;;;;;;;;;;;;;;;;;;;;;;
    xor bx, bx
    push 0
    
    .insert_num:
        mov ah, 01h
        int 21h
        
        cmp al, 13
        je .calculate
        
        mov bl, 30h
        sub al, bl
        mov bl, al
        
        pop ax
        mov cx, 10
        mul cx
        add ax, bx
        
        push ax
        
        jmp .insert_num
    
    
    
    .calculate: 
        pop ax
        div num
        .calculate_after:
             cmp ax, 0
             je .print
             
             xor dx, dx
             mov bx, 10
             div bx
             
             add dx, 30h
             push dx
             
             jmp .calculate_after
     
    .print:
        pop dx
        cmp dx, 0
        je .end
        
        mov ah, 02h
        int 21h
        
        jmp .print
        
    .end:
    
;;;;;;;;;;;;;;;;;;;;;;;;

    mov ax, 4c00h
    int 21h
end N