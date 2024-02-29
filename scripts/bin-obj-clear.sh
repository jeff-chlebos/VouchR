#!/bin/bash

find ./src -name 'bin' -type d -print0 | xargs -0 rm -rf
find ./src -name 'obj' -type d -print0 | xargs -0 rm -rf
