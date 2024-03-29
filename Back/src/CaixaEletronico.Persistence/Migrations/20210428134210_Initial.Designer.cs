﻿// <auto-generated />
using CaixaEletronico.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaixaEletronico.Persistence.Migrations
{
    [DbContext(typeof(CaixaEletronicoContext))]
    [Migration("20210428134210_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CaixaEletronico.Domain.Caixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescricaoLocal")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Caixas");
                });

            modelBuilder.Entity("CaixaEletronico.Domain.CaixaNota", b =>
                {
                    b.Property<int>("CaixaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NotaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CaixaId", "NotaId");

                    b.HasIndex("NotaId");

                    b.ToTable("CaixaNotas");
                });

            modelBuilder.Entity("CaixaEletronico.Domain.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagemURl")
                        .HasColumnType("TEXT");

                    b.Property<int>("QrtCriticaNota")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QtdNota")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Valor")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("CaixaEletronico.Domain.CaixaNota", b =>
                {
                    b.HasOne("CaixaEletronico.Domain.Caixa", "Caixa")
                        .WithMany("CaixaNotas")
                        .HasForeignKey("CaixaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaixaEletronico.Domain.Nota", "Nota")
                        .WithMany("CaixaNotas")
                        .HasForeignKey("NotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caixa");

                    b.Navigation("Nota");
                });

            modelBuilder.Entity("CaixaEletronico.Domain.Caixa", b =>
                {
                    b.Navigation("CaixaNotas");
                });

            modelBuilder.Entity("CaixaEletronico.Domain.Nota", b =>
                {
                    b.Navigation("CaixaNotas");
                });
#pragma warning restore 612, 618
        }
    }
}
