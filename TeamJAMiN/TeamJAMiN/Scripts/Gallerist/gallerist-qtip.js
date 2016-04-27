$('[title!=""]').qtip({ //set all items with a non empty string as their title to use qtip
    position: {
        target: 'mouse',
        adjust: {
            mouse: false 
        }
    },
    hide: {
        fixed: true, //without this hovering on the tooltip itself causes problems with mouseout not closing the tooltip until you mouse back in
        when: {
            event: 'unfocus',
            delay: 0            
        },        
    }
}); 
