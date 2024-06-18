#!/bin/bash

if [ $# != 2 ]; then
	echo "Invalid number of arguments"
	exit 1
fi

source_dir=$1
file_type=$2

output_folder="$source_dir/output" 

mkdir -p "$output_folder"

cp -r "$source_dir"/*"$file_type" "$output_folder"

echo "Copy completed."


