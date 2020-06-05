﻿// <auto-generated />
using System;
using Labs.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Labs.Infra.Migrations
{
    [DbContext(typeof(LabsContext))]
    partial class LabsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Labs.Domain.Exames.Entities.Exame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("character varying(60)")
                        .HasMaxLength(60);

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp");

                    b.Property<decimal>("Preco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Exames");
                });

            modelBuilder.Entity("Labs.Domain.Medicos.Entities.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(60)")
                        .HasMaxLength(60);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("Labs.Domain.OrdensServico.Entities.OrdemServico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Convenio")
                        .IsRequired()
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("DataExame")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("DataRetirada")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PostoColetaId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("PostoColetaId");

                    b.ToTable("OrdensServico");
                });

            modelBuilder.Entity("Labs.Domain.OrdensServico.Entities.OrdemServicoExame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<Guid>("ExameId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp");

                    b.Property<Guid>("OrdemServicoId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OrdemServicoId1")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Preco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("ExameId");

                    b.HasIndex("OrdemServicoId");

                    b.HasIndex("OrdemServicoId1");

                    b.ToTable("OrdemServicoExames");
                });

            modelBuilder.Entity("Labs.Domain.Pacientes.Entities.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(60)")
                        .HasMaxLength(60);

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("character varying(1)")
                        .HasMaxLength(1);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Labs.Domain.PostosColeta.Entities.PostoColeta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("character varying(60)")
                        .HasMaxLength(60);

                    b.Property<Guid>("LabId")
                        .HasColumnType("uuid")
                        .HasMaxLength(32);

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("PostosColeta");
                });

            modelBuilder.Entity("Labs.Domain.OrdensServico.Entities.OrdemServico", b =>
                {
                    b.HasOne("Labs.Domain.Medicos.Entities.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labs.Domain.Pacientes.Entities.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labs.Domain.PostosColeta.Entities.PostoColeta", "PostoColeta")
                        .WithMany()
                        .HasForeignKey("PostoColetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Labs.Domain.OrdensServico.Entities.OrdemServicoExame", b =>
                {
                    b.HasOne("Labs.Domain.Exames.Entities.Exame", "Exame")
                        .WithMany()
                        .HasForeignKey("ExameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labs.Domain.OrdensServico.Entities.OrdemServico", "OrdemServico")
                        .WithMany()
                        .HasForeignKey("OrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labs.Domain.OrdensServico.Entities.OrdemServico", null)
                        .WithMany("Exames")
                        .HasForeignKey("OrdemServicoId1");
                });

            modelBuilder.Entity("Labs.Domain.Pacientes.Entities.Paciente", b =>
                {
                    b.OwnsOne("Labs.Domain.Miscellaneous.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("PacienteId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Bairro")
                                .HasColumnName("Bairro")
                                .HasColumnType("character varying(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("Cep")
                                .HasColumnName("Cep")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("Cidade")
                                .HasColumnName("Cidade")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Complemento")
                                .HasColumnName("Complemento")
                                .HasColumnType("character varying(30)")
                                .HasMaxLength(30);

                            b1.Property<string>("Estado")
                                .HasColumnName("Estado")
                                .HasColumnType("character varying(2)")
                                .HasMaxLength(2);

                            b1.Property<string>("Logradouro")
                                .HasColumnName("Logradouro")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Numero")
                                .HasColumnName("Numero")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.HasKey("PacienteId");

                            b1.ToTable("Pacientes");

                            b1.WithOwner()
                                .HasForeignKey("PacienteId");
                        });
                });

            modelBuilder.Entity("Labs.Domain.PostosColeta.Entities.PostoColeta", b =>
                {
                    b.OwnsOne("Labs.Domain.Miscellaneous.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("PostoColetaId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Bairro")
                                .HasColumnName("Bairro")
                                .HasColumnType("character varying(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("Cep")
                                .HasColumnName("Cep")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("Cidade")
                                .HasColumnName("Cidade")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Complemento")
                                .HasColumnName("Complemento")
                                .HasColumnType("character varying(30)")
                                .HasMaxLength(30);

                            b1.Property<string>("Estado")
                                .HasColumnName("Estado")
                                .HasColumnType("character varying(2)")
                                .HasMaxLength(2);

                            b1.Property<string>("Logradouro")
                                .HasColumnName("Logradouro")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Numero")
                                .HasColumnName("Numero")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.HasKey("PostoColetaId");

                            b1.ToTable("PostosColeta");

                            b1.WithOwner()
                                .HasForeignKey("PostoColetaId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
