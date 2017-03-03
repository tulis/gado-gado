" IMPORTANT: Uncomment one of the following lines to force
" using 256 colors (or 88 colors) if your terminal supports it,
" but does not automatically use 256 colors by default.
"set t_Co=256
"set t_Co=88
if (&t_Co == 256 || &t_Co == 88) &&!has('gui_running') &&
  \ filereadable(expand("$HOME/.vim/plugin/guicolorscheme.vim"))
  " Use the guicolorscheme plugin to makes 256-color or 88-color
  " terminal use GUI colors rather than cterm colors.
  runtime! plugin/guicolorscheme.vim
  GuiColorScheme wombat256i
else
  " For 8-color 16-color terminals or for gvim, just use the
  " regular:colorscheme command.
  colorscheme wombat256i
endif

if !has("gui_running")
    set term=xterm
    set t_Co=256
    let &t_AB="\e[48;5;%dm"
    let &t_AF="\e[38;5;%dm"
    colorscheme wombat256i
endif


" Set encoding
set encoding=utf-8

" Set color-column
highlight ColorColumn ctermbg=gray
set colorcolumn=81



" VIM-PLUGIN
" Specify a directory for plugins (for Neovim: ~/.local/share/nvim/plugged)
call plug#begin('~/.vim/plugged')

" Make sure you use single quotes

" Any valid git URL is allowed
Plug 'https://github.com/scrooloose/nerdtree.git'
Plug 'https://github.com/junegunn/rainbow_parentheses.vim.git'
Plug 'https://github.com/vim-scripts/AutoClose.git'
Plug 'https://github.com/pangloss/vim-javascript.git'
Plug 'https://github.com/tpope/vim-surround.git'
Plug 'https://github.com/kien/ctrlp.vim.git'
Plug 'https://github.com/Valloric/YouCompleteMe.git'
Plug 'https://github.com/airblade/vim-gitgutter.git'
Plug 'https://github.com/mattn/emmet-vim.git'
Plug 'https://github.com/scrooloose/nerdcommenter.git'
Plug 'https://github.com/jparise/vim-graphql.git'
Plug 'https://github.com/tpope/vim-fugitive'
Plug 'https://github.com/vim-syntastic/syntastic.git'
Plug 'vim-airline/vim-airline'
Plug 'vim-airline/vim-airline-themes'

" Initialize plugin system
call plug#end()




" Rainbow Parentheses
" Turn on Rainbow Parentheses by default
autocmd FileType * RainbowParentheses
let g:rainbow#max_level = 16
let g:rainbow#pairs = [['(', ')'], ['[', ']']]

" List of colors that you do not want. ANSI code or #RRGGBB
let g:rainbow#blacklist = [233, 234]


" VIM AIRLINE SUPERMAN
let g:airline#extensions#tabline#enabled = 1
let g:airline#extensions#tabline#left_sep = ' '
let g:airline#extensions#tabline#left_alt_sep = '|'
let g:airline_theme = 'wombat'


" TERN
let g:ycm_min_num_of_chars_for_completion = 0
let g:ycm_auto_trigger = 1



