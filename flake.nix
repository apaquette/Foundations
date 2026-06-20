{
description = "Godot C# development environment (NixOS flake)";

inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
};

outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
        let
            pkgs = import nixpkgs {
                inherit system;
                config.allowUnfree = true;
            };

            dotnet = pkgs.dotnet-sdk_10;
            godot = pkgs.godot-mono;

        in {
            devShells.default = pkgs.mkShell {
                packages = [
                    godot
                    dotnet
                    pkgs.git
                ];

                shellHook = ''
                export DOTNET_ROOT=${dotnet}
                export DOTNET_CLI_HOME=$HOME/.dotnet
                export PATH=$DOTNET_ROOT/bin:$PATH

                echo "Godot C# dev shell ready"
                echo "Godot: $(which godot)"
                echo "dotnet: $(dotnet --version)"
                
                # Git Configuration
                git config --global user.name "Alex Paquette"
                git config --global user.email "alexandre.d.paquette@gmail.com"

                exec fish
                '';
            };
        }
    );
}
