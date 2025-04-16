.model tiny

.data
    A dw 10, 15, 20, 25, 30, 35, 40, 45
    B dw 1, 115, 2, 225, 3, 335, 4, 445
    C dw 0, 0, 0, 0, 0, 0, 0, 0
.code

N:
    push cs
    push ds
    
;;;;;;;;;;;;;;;;;;;;;;;;
    mov bx, 0
    mov cx, 8

    m:
        mov ax, A[bx]
        mov dx, B[bx]
        
        cmp ax, dx
        jge .insert_a
        
        cmp dx, ax
        jge .insert_b

    .insert_a:
        mov C[bx], ax
        add bx, 2
        loop m
    
    .insert_b:
        mov C[bx], dx
        add bx, 2
        loop m
     
     .end:
     
;;;;;;;;;;;;;;;;;;;;;;;;

    mov ax, 4c00h
    int 21h
end N