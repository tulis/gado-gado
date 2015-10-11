 **Setup elm environment in Windows**

1. Go to **[Install Elm page](http://elm-lang.org/install)** to download the installer for Windows

    <img src="img/01_elm-download-elm-for-windows.PNG" alt="download elm for windows" width="500" />
2. Next, run and install it in Administrator mode
3. Make sure that Atom has been installed in your machine, otherwise click **[here](https://atom.io/)** to install it
4. Open command line (cmd)
5. Enter the following command line

    <img src="img/03_npm-install-elm-oracle.PNG" alt="npm install -g elm-oracle" />
6. Copy the following path

    ```
        C:\Users\tulis\.atom\packages\language-elm\node_modules\.bin\elm-oracle
    ```
    **NOTE:** The above path is relative to your User directory path, in this case, it is tulis directory.
7. Open atom editor
8. Open Settings through Command Pallete (Ctrl + Shift + P), then type Settings
9. Install both **language-elm** and **linter-elm-make**

    <img src="img/04_install-elm-syntax-and-elm-linter.PNG" alt="install-elm-syntax-and-elm-linter" width="500" />
10. Open **language-elm** settings and paste the copied path from step number 6 to enable the auto-complete feature

    <img src="img/05_paste-elm-oracle-path-for-autocomplete-in-atom.PNG" alt="paste-elm-oracle-path-for-autocomplete-in-atom" width="500" />
11. To enable elm linter, copy the following path

    ```
        C:\Program Files (x86)\Elm Platform\0.15.1\bin\elm-make.exe
    ```
12. Open **linter-elm-make** settings and paste the copied path from previous step

    <img src="img/06_paste-elm-make-path-for-elm-linter.PNG" alt="elm-make-path-for-elm-linter" width="500" />
13. Lastly, make sure that Atom is using **Soft** Tab type (personally, I use 4 spaces), otherwise Elm compiler will throw following exception:

    <img src="img/07_syntax-problem-looking-for-whitespace.PNG" alt="syntax-problem-looking-for-whitespace" width="500" />

    <img src="img/08_atom-tab-type.PNG" alt="atom-tab-type" width="500" />
